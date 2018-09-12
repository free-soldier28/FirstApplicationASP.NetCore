import { Component, OnInit } from '@angular/core';
import { UserService } from '../user/user.service';
import { User } from '../user/user';
import { RoleService } from '../role/role.service';
import { Role } from '../role/role';

@Component({
    selector: 'users-page',
    templateUrl: './users-page.component.html',
    providers: [UserService, RoleService]
})

export class UsersPageComponent implements OnInit {
    users: User[];
    user: User = new User();
    userRole: Role[];
    role: Role = new Role();
    tableMode: boolean = true;         

    constructor(private userService: UserService, private roleService: RoleService) { }

    ngOnInit() {
        this.loadUsers();     
    }

    loadUsers(){
        this.userService.getUsers()
            .subscribe((data: User[]) => this.users = data);
    }

    save()
    {
        if (this.user.id == null)
        {
            this.userService.createUser(this.user)
                .subscribe((data: User) => this.users.push(data));
        }
        else {
            this.userService.updateUser(this.user)
                .subscribe(data => this.loadUsers());
        }
        this.cancel();
    }

    editUser(p: User) {
        this.user = p;
    }

    cancel() {
        this.user = new User();
        this.tableMode = true;
    }

    delete(p: User) {
        this.userService.deleteUser(p.id)
            .subscribe(data => this.loadUsers());
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
}