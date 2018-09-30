import { User } from "./EF";

export class BugReport {
  ID_BugReport: Number;
  ReportUser: User;
  ReportTime: Date;
  Report: string;
  ReportTitle: string;
  Error: string;
  Notified: boolean;
  NotifyTime: Date;

  deserialize(input): BugReport {
    this.ID_BugReport = input.ID_BugReport;
    this.ReportUser = new User().deserialize(input.User);
    this.ReportTime = input.ReportTime;
    this.Report = input.Report;
    this.ReportTitle = input.ReportTitle;
    this.Error = input.Error;
    this.Notified = input.Notified;
    this.NotifyTime = input.NotifyTime;
    return this;
  }
}
