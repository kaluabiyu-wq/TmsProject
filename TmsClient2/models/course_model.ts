
import { Temporal } from "@js-temporal/polyfill";

export interface Course {
    readonly id:string;
    title: string;
    capacity:number;
    startDate?:Temporal.PlainDate;
    
}

export type CourseStatus =
| { status: "DRAFT"; createdBy: string; createdAt: Temporal.Instant }
| { status: "PUBLISHED"; publishedAt: Temporal.Instant; syllabus: string }
| {
status: "ACTIVE";
enrolledCount: number;
startDate: Temporal.PlainDate;
}
| {
status: "ARCHIVED";
archivedAt: Temporal.Instant;
finalEnrollmentCount: number;
}
| { status: "CANCELLED"; reason: string; cancelledAt: Temporal.Instant };

export function describeCourse(status: CourseStatus): string {
switch (status.status) {
case "DRAFT":
return `Draft since ${status.createdBy}`;
case "PUBLISHED":
return `Published by ${status.publishedAt}`;
case "ACTIVE":
return status.enrolledCount !== undefined
? `In progress Course so far: ${status.enrolledCount}`
: `In progress not yet course`;
case "ARCHIVED":
return `Archived in  ${status.archivedAt}`;
case "CANCELLED":
return `Dropped: ${status.cancelledAt}`;
default: {
const _check: never = status;
throw new Error(`Unhandled status: ${JSON.stringify(_check)}`);
}
}
}