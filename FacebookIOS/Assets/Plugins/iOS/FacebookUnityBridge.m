//
//  FacebookUnityBridge.m
//  Unity-iPhone
//
//  Created by Ranier Montalbo on 1/8/13.
//
//

#import "FacebookManager.h"

void _fbOpenSession() {
    [[FacebookManager sharedManager] openSession];
}

void _fbCloseSession() {
    [[FacebookManager sharedManager] closeSession];
}

bool _fbHasOpenSession() {
    return [[FacebookManager sharedManager] hasOpenSession];
}

void _fbShowDialog() {
    
}