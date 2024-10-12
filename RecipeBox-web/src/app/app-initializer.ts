import { AuthenticationService, AuthorizationData, AuthorizationService, Logger } from '@muziehdesign/core';
import { delay, firstValueFrom, map, tap } from 'rxjs';
import { RecipeBoxClient } from './api/shopping-cart/shopping-cart.client';

export const initializeApplication = (logger: Logger): (() => Promise<void>) => {
    return (): Promise<void> => {
        /*authenticationService.onUserSignedOut().pipe(tap((x) => authorizationService.reset()));
        authenticationService.onUserSignedIn().pipe(    
            delay(1000),  //this is to prevent the authorization api call from firing before authentication user is done being set      
            switchMap((x) => client.getAuthorization()),
            tap((x) => {
                const map = new Map<string, AuthorizationData>();
                map.set(RecipeBoxClient.name, x as AuthorizationData);
            })
        ).subscribe();

        return authenticationService.initialize();*/
        return Promise.resolve();
    };
};

export const initializeAuthorization = (authentication: AuthenticationService, authorization: AuthorizationService, client: RecipeBoxClient): (() => Promise<boolean>) => {
    return async (): Promise<boolean> => {
        const authenticated = await authentication.isAuthenticated();
        if (!authenticated) {
            return Promise.resolve(true);
        }

        return firstValueFrom(
            client.getAuthorization().pipe(
                tap((x) => authorization.register('RecipeBoxClient', x as AuthorizationData)),
                map((x) => true)
            )
        );
    };
};

