//
//  InAppBrowserViewController.m
//  Unity-iPhone
//
//  Created by Piotr on 04/03/16.
//
//
#include "InAppBrowserViewController.h"
extern void UnitySendMessage(const char *, const char *, const char *);

static NSString *GameObjectName = @"InAppBrowserBridge";

void SendToUnity(NSString *methodName, NSString *param) {
    UnitySendMessage(GameObjectName.UTF8String, methodName.UTF8String, param.UTF8String);
}

void OnBrowserJSCallback(NSString *callbackMessage) {
    SendToUnity(@"OnBrowserJSCallback", callbackMessage);
}

void OnBrowserFinishedLoading(NSURLRequest *request) {
    SendToUnity(@"OnBrowserFinishedLoading", request.URL.absoluteString);
}

void OnBrowserClosed() {
    SendToUnity(@"OnBrowserClosed", @"");
}

void OnBrowserFinishedLoadingWithError(NSURLRequest *request, NSError *error) {
    SendToUnity(@"OnBrowserFinishedLoadingWithError", [NSString stringWithFormat:@"%@,%@",
                                                       request.URL.absoluteString,
                                                       error.description]);
}

@implementation InAppBrowserConfig

+ (InAppBrowserConfig *)defaultDisplayOptions {
    InAppBrowserConfig *displayOptions = [InAppBrowserConfig new];
    displayOptions.pageTitle = nil;
    displayOptions.displayURLAsPageTitle = YES;
    displayOptions.textColor = nil;
    displayOptions.barBackgroundColor = nil;
    displayOptions.backButtonText = @"Back";
    return displayOptions;
}

@end

@implementation InAppBrowserViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    if (!_config) {
        _config = [InAppBrowserConfig defaultDisplayOptions];
    }
    
    UIWebView *webView = [UIWebView new];
    self.webView = webView;
    [self.view addSubview:webView];
    [self configureNavigationBar];
    [webView setTranslatesAutoresizingMaskIntoConstraints:NO];
    [self.view addConstraints:[NSLayoutConstraint
                               constraintsWithVisualFormat:@"H:|-0-[webView]-0-|"
                               options:NSLayoutFormatDirectionLeadingToTrailing
                               metrics:nil
                               views:NSDictionaryOfVariableBindings(webView)]];
    
    [self.view addConstraints:[NSLayoutConstraint
                               constraintsWithVisualFormat:@"V:|-0-[webView]-0-|"
                               options:NSLayoutFormatDirectionLeadingToTrailing
                               metrics:nil
                               views:NSDictionaryOfVariableBindings(webView)]
     ];
    [self startLoadingWebView];
}

- (void)sendJSMessage:(NSString *)message {
    [_webView stringByEvaluatingJavaScriptFromString:message];
}

- (void)startLoadingWebView {
    _webView.delegate = self;
    NSURLRequest *request = [NSURLRequest requestWithURL:[NSURL URLWithString:_URL]];
    [_webView loadRequest: request];
    
    UIActivityIndicatorView *indicator = [[UIActivityIndicatorView alloc] initWithActivityIndicatorStyle:UIActivityIndicatorViewStyleGray];
    _indicatorView.hidesWhenStopped  = YES;
    self.indicatorView = indicator;
    [self.view addSubview:_indicatorView];
    [_indicatorView setTranslatesAutoresizingMaskIntoConstraints:NO];
    [self.view addConstraints:@[[NSLayoutConstraint constraintWithItem:_indicatorView
                                                            attribute:NSLayoutAttributeCenterX
                                                            relatedBy:NSLayoutRelationEqual
                                                               toItem:self.view
                                                            attribute:NSLayoutAttributeCenterX
                                                           multiplier:1.f constant:0.f],
                               [NSLayoutConstraint constraintWithItem:_indicatorView
                                                            attribute:NSLayoutAttributeCenterY
                                                            relatedBy:NSLayoutRelationEqual
                                                               toItem:self.view
                                                            attribute:NSLayoutAttributeCenterY
                                                           multiplier:1.f constant:0.f]
                                ]
     
     ];
    [_indicatorView startAnimating];
}

- (void)configureNavigationBar {
    
    if (_config.hidesTopBar) {
        self.navigationController.navigationBarHidden = YES;
        return;
    }
    
    UIBarButtonItem* barButton = [[UIBarButtonItem alloc] initWithTitle:_config.backButtonText
                                                                  style:UIBarButtonItemStylePlain
                                                                 target:self
                                                                 action:@selector(backButtonPressed)];
    
    [self.navigationItem setLeftBarButtonItem:barButton];
    
    if (_config.textColor) {
        NSDictionary *titleTextAttrs = [NSDictionary dictionaryWithObject:_config.textColor
                                                                    forKey:NSForegroundColorAttributeName];
        [self.navigationController.navigationBar setTitleTextAttributes: titleTextAttrs];
        [barButton setTitleTextAttributes:titleTextAttrs forState:UIControlStateNormal];
    }

    if (_config.barBackgroundColor) {
        self.navigationController.navigationBar.barTintColor = _config.barBackgroundColor;
        self.navigationController.navigationBar.translucent = NO;
    }
    
    if (_config.displayURLAsPageTitle) {
        NSURL *URL = [NSURL URLWithString:_URL];
        if (URL != nil) {
            self.navigationItem.title = URL.host;
        }

    } else if (_config.pageTitle) {
        self.navigationItem.title = _config.pageTitle;
    }
    
}

- (BOOL)webView:(UIWebView *)webView shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType {
    NSString *scheme = request.URL.scheme;
    if ([scheme isEqualToString:@"inappbrowserbridge"]) {
        NSString *wholeMessage = [request.URL.absoluteString stringByReplacingOccurrencesOfString:@"inappbrowserbridge://" withString:@""];
        
        OnBrowserJSCallback([wholeMessage stringByReplacingPercentEscapesUsingEncoding:NSUTF8StringEncoding]);
        return NO;
    }
    return YES;
}


- (void)webViewDidFinishLoad:(UIWebView *)webView {
    [_indicatorView stopAnimating];
    OnBrowserFinishedLoading(webView.request);
}

- (void)webView:(UIWebView *)webView didFailLoadWithError:(NSError *)error {
    [_indicatorView stopAnimating];
    OnBrowserFinishedLoadingWithError(webView.request, error);
}

- (void)backButtonPressed {
    [self.navigationController.presentingViewController dismissViewControllerAnimated:true completion:^{
        OnBrowserClosed();
    }];
}

@end
