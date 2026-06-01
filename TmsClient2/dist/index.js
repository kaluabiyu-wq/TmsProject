"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const polyfill_1 = require("@js-temporal/polyfill");
const stidemt_model_1 = require("./models/stidemt_model");
const assessment_mode_1 = require("./models/assessment.mode");
const enrollment_model_1 = require("./models/enrollment_model");
const course_model_1 = require("./models/course_model");
const student = {
    id: "STU-001",
    name: "Hana Tadesse",
    enrollmentDate: polyfill_1.Temporal.Now.instant(),
};
//student.id = "STU-999";
console.log(student.gpa?.toFixed(2));
console.log(student.gpa?.toFixed(2) ?? "Not Yet graded");
function processStudent(raw) {
    if ((0, stidemt_model_1.isStudent)(raw)) {
        const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
        console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
    }
    else {
        console.error("invalid student data received");
    }
}
// processStudent({id:"STU-001",name:"Hana",gpa:3.7});
// processStudent(42);
//  console.log(parseStudent({id:"STU-001",name:"Hana"}));
// parseStudent({id:42,name:"Test"});
const quiz = {
    id: "QUIZ-001",
    kind: "quiz",
    title: "SQL Basics",
    correctAnswer: 8,
    totalQuestions: 10,
};
const lab = {
    id: "LAB-001",
    kind: "lab",
    title: "REST API Project",
    functionalityScore: 85,
    codeQualityScore: 90,
};
console.log(`Quiz grade: ${(0, assessment_mode_1.calculateGrade)(quiz)}%`); // 80
console.log(`Lab grade: ${(0, assessment_mode_1.calculateGrade)(lab)}%`); // 87
const pending = {
    status: "PENDING",
    requestedAt: polyfill_1.Temporal.Now.instant(),
    studentId: "STU-001",
    courseId: "CRS-101",
};
console.log((0, enrollment_model_1.describeEnrollment)(pending));
const webDev = {
    status: "ACTIVE",
    enrolledCount: 28,
    startDate: polyfill_1.Temporal.PlainDate.from("2026-09-01"),
};
console.log((0, course_model_1.describeCourse)(webDev));
