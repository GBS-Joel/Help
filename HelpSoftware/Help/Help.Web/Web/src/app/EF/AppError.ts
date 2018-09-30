export class AppError {
  ID_AppError: Number;
  ErrorMessage: string;
  StrackTrace: string;
  Created: Date;

  deserialize(input) {
    this.ID_AppError = input.ID_AppError;
    this.ErrorMessage = input.ErrorMessage;
    this.StrackTrace = input.StrackTrace;
    this.Created = input.Created;
    return this;
  }
}
