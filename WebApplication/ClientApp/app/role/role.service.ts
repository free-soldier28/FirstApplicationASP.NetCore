import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Role } from './role';

@Injectable()
export class RoleService {

    private url = "/roles";

    constructor(private http: HttpClient) {
    }

    getRoles() {
        return this.http.get(this.url);
    }

    createRole(role: Role) {
        return this.http.post(this.url, role);
    }

    updateRole(role: Role) {
        return this.http.put(this.url + '/' + role.id, role);
    }

    deleteRole(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}