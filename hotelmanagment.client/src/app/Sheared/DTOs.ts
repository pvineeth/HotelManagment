export class LoginDTO implements ILoginDTO {
  userMail?: string | null;
  password?: string | null;

  constructor(data?: ILoginDTO) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

  init(_data?: any) {
    if (_data) {
      this.userMail = _data["userMail"] !== undefined ? _data["userMail"] : <any>null;
      this.password = _data["password"] !== undefined ? _data["password"] : <any>null;
    }
  }

  static fromJS(data: any): LoginDTO {
    data = typeof data === 'object' ? data : {};
    let result = new LoginDTO();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === 'object' ? data : {};
    data["userMail"] = this.userMail !== undefined ? this.userMail : <any>null;
    data["password"] = this.password !== undefined ? this.password : <any>null;
    return data;
  }
}

export interface ILoginDTO {
  userMail?: string | null;
  password?: string | null;
}

export class LoginResponse implements ILoginResponse {
  readonly success?: boolean;
  errorMessage?: string | null;
  token?: string | null;

  constructor(data?: ILoginResponse) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

  init(_data?: any) {
    if (_data) {
      (<any>this).success = _data["success"] !== undefined ? _data["success"] : <any>null;
      this.errorMessage = _data["errorMessage"] !== undefined ? _data["errorMessage"] : <any>null;
      this.token = _data["token"] !== undefined ? _data["token"] : <any>null;
    }
  }

  static fromJS(data: any): LoginResponse {
    data = typeof data === 'object' ? data : {};
    let result = new LoginResponse();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === 'object' ? data : {};
    data["success"] = this.success !== undefined ? this.success : <any>null;
    data["errorMessage"] = this.errorMessage !== undefined ? this.errorMessage : <any>null;
    data["token"] = this.token !== undefined ? this.token : <any>null;
    return data;
  }
}

export interface ILoginResponse {
  success?: boolean;
  errorMessage?: string | null;
  token?: string | null;
}
