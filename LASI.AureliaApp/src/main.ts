import { Aurelia, inject } from 'aurelia-framework';
import { HttpClientConfiguration, HttpClient } from 'aurelia-fetch-client';
import { WindowService, getHostElement } from './helpers';
import TokenService from './app/token-service';
import configureDialogs from './configuration/dialog';
import configureTypeahead from './configuration/typeahead';

export async function configure(aurelia: Aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging()
        // .plugin('aurelia-dialog', configureDialogs)
        // .plugin('aurelia-typeahead', configureTypeahead)
        .transient(HttpClient, class extends HttpClient {
            static inject = [TokenService];
            constructor(private tokenService: TokenService) {
                super();
                super.configure(config => {
                    return config
                        .useStandardConfiguration()
                        .withBaseUrl('//localhost:51641')
                        .withDefaults({ credentials: 'include', mode: 'cors' })
                        .rejectErrorResponses()
                        .withInterceptor({
                            request(config) {
                                if (tokenService.token) {
                                    config.headers.append('Authorization', `Bearer ${tokenService.token}`);
                                }
                                config.headers.append('Scheme', 'Bearer');
                                config.headers.append('WWW-Authenticate', 'Bearer');
                                return config;
                            }
                        });
                });
            }
        });

    const a = await aurelia.start();
    await a.setRoot('src/app/app', getHostElement());
}