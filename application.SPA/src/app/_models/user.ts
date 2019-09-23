export interface IUser {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    role:string;
}

export class User implements IUser {

    constructor(
        public id: string,
        public firstName: string,
        public lastName: string,
        public email: string,
        public role:string
    ) { }
}

export interface IUserEditor {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    role: string;
}

export class UserEditor implements IUserEditor {

    constructor(
        public id: string,
        public firstName: string,
        public lastName: string,
        public email: string,
        public password: string,
        public role: string,
    ) { }
}

export interface IAuthUser {
    auth_token: string;
}

export interface Credentials {
    userName: string;  
    password: string;
}