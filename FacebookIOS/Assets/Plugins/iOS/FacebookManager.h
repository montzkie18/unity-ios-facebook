//
//  FacebookManager.h
//  Unity-iPhone
//
//  Created by Ranier Montalbo on 1/8/13.
//
//

#import <Foundation/Foundation.h>
#import "FacebookSDK.h"

#define UNITY_FBLISTENER_GAMEOBJECT_NAME        "FacebookListener"
#define UNITY_FBLISTENER_ONSESSIONSTATECHANGED  "OnFbSessionStateChanged"

@interface FacebookManager : NSObject

@property (nonatomic, retain) FBSession * session;
@property (nonatomic, retain) UIViewController * overlayViewController;

+(FacebookManager*)sharedManager;

-(void)openSession;

-(void)closeSession;

-(BOOL)hasOpenSession;

-(void)showDialog;

@end
