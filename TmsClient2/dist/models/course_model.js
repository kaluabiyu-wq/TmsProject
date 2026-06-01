"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.describeCourse = describeCourse;
function describeCourse(status) {
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
            const _check = status;
            throw new Error(`Unhandled status: ${JSON.stringify(_check)}`);
        }
    }
}
