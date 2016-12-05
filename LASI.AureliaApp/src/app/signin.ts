import $ from 'jquery';
import {autoinject, bindable} from 'aurelia-framework';
import {AppRouter} from 'aurelia-router';
import {HttpClient} from 'aurelia-fetch-client';

import {User} from 'src/models';
import UserService from './services/user';

@autoinject export class Signin {
    constructor(private userService: UserService, readonly router: AppRouter) { }

    async login(): Promise<User> {
        this.user = await this.userService
            .login({
                email: this.username,
                password: this.password,
                rememberMe: this.rememberMe || this.user && this.user.rememberMe
            });
        [this.username, this.rememberMe] = [this.user.email, this.user.rememberMe];
        const nav = await this.router.loadUrl('documents');

        return this.user;

        // return this.$state.go('app.home', {}, { reload: true });
        // .catch(reason => {
        //     return this.$uibModal.open({
        //         controllerAs: 'modal',
        //         bindToController: true,
        //         template: errorModalTemplate,
        //         controller: class {
        //             static $inject = ['$uibModalInstance'];
        //             constructor(private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance) { }

        //             header = 'Login Failed';

        //             error = reason;

        //             ok() {
        //                 this.$uibModalInstance.close();
        //                 return this.$uibModalInstance.result;
        //             }
        //         }
        //     }).result;
        // });
    }
    user: any;
    username: string;
    password: string;
    rememberMe: boolean = false;
}