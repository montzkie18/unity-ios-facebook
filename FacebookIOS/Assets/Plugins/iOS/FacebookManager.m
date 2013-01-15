//
//  FacebookManager.m
//  Unity-iPhone
//
//  Created by Ranier Montalbo on 1/8/13.
//
//

#import "FacebookManager.h"

@implementation FacebookManager

@synthesize session;
@synthesize overlayViewController;

+(FacebookManager*)sharedManager {
    static FacebookManager * sharedInstance;
    if(sharedInstance == NULL)
        sharedInstance = [[FacebookManager alloc] init];
    return sharedInstance;
}

-(void)openSession {
    NSLog(@"%s", __func__);
    
    NSString *fbAppId = [[NSUserDefaults standardUserDefaults] stringForKey:@"fbAppId"];
    if(session == NULL || session.state != FBSessionStateCreated) {
        [FBSession setDefaultAppID:fbAppId];
        [session release];
        session = [[FBSession alloc] init];
    }
    
    [session openWithCompletionHandler:^(FBSession *session, FBSessionState status, NSError *error) {
        NSLog(@"Facebook Session State: %d Error: %@", status, [error localizedDescription]);
        NSString * statusMessage = [NSString stringWithFormat:@"%d|%@", status, [error localizedDescription]];
        const char * statusMessageC = [statusMessage cStringUsingEncoding:NSStringEncodingConversionAllowLossy];
        UnitySendMessage(UNITY_FBLISTENER_GAMEOBJECT_NAME, UNITY_FBLISTENER_ONSESSIONSTATECHANGED, statusMessageC);
    }];
}

-(void)closeSession {
    NSLog(@"%s", __func__);
    [session closeAndClearTokenInformation];
}

-(BOOL)hasOpenSession {
    NSLog(@"%s", __func__);
    return session.isOpen;
}

-(void)showDialog {
    NSLog(@"%s", __func__);
}

@end
