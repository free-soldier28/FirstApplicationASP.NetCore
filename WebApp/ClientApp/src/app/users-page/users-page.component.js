var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { UserService } from '../user/user.service';
import { User } from '../user/user';
import { RoleService } from '../role/role.service';
var UsersPageComponent = /** @class */ (function () {
    function UsersPageComponent(userService, roleService) {
        this.userService = userService;
        this.roleService = roleService;
        this.users = [];
        this.user = new User();
        this.tableMode = true;
    }
    UsersPageComponent.prototype.ngOnInit = function () {
        this.loadUsers();
    };
    UsersPageComponent.prototype.loadUsers = function () {
        var _this = this;
        //this.userService.getUsers().subscribe((data: User[]) => this.users = data);
        this.userService.getUsersRolePagination()
            .subscribe(function (data) { return _this.users = data["rolesDTO"]; });
    };
    UsersPageComponent.prototype.save = function () {
        var _this = this;
        if (this.user.id == null) {
            this.userService.createUser(this.user)
                .subscribe(function (data) { return _this.users.push(data); });
        }
        else {
            this.userService.updateUser(this.user)
                .subscribe(function (data) { return _this.loadUsers(); });
        }
        this.cancel();
    };
    UsersPageComponent.prototype.editUser = function (p) {
        this.user = p;
    };
    UsersPageComponent.prototype.cancel = function () {
        this.user = new User();
        this.tableMode = true;
    };
    UsersPageComponent.prototype.delete = function (p) {
        var _this = this;
        this.userService.deleteUser(p.id)
            .subscribe(function (data) { return _this.loadUsers(); });
    };
    UsersPageComponent.prototype.add = function () {
        this.cancel();
        this.tableMode = false;
    };
    UsersPageComponent = __decorate([
        Component({
            selector: 'users-page',
            templateUrl: './users-page.component.html',
            providers: [UserService, RoleService]
        }),
        __metadata("design:paramtypes", [UserService, RoleService])
    ], UsersPageComponent);
    return UsersPageComponent;
}());
export { UsersPageComponent };
//# sourceMappingURL=users-page.component.js.map