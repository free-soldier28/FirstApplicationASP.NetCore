import { Role } from "../role/role";

export class User {
    constructor(
        public id?: number,
        public name?: string,
        public rolesDTO?: Role[]
    ) { }
}
