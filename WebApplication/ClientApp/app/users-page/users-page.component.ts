import { Component, OnInit } from '@angular/core';
import { UserService } from '../user/user.service';
import { User } from '../user/user';

@Component({
    selector: 'users-page',
    templateUrl: './users-page.component.html',
    providers: [UserService]
})

export class UsersPageComponent implements OnInit {

    users: User[];  
    user: User = new User();  
    tableMode: boolean = true;         

    constructor(private userService: UserService) { }

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