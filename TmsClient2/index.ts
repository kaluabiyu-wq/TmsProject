
import { Temporal } from "@js-temporal/polyfill";
 import { Student,isStudent } from "./models/stidemt_model";
 import { parseStudent } from "./models/stidemt_model";
 import { AssessmentItem,calculateGrade } from "./models/assessment.mode";
 import { EnrollmentStatus,describeEnrollment } from "./models/enrollment_model";
 import { CourseStatus, describeCourse } from "./models/course_model";

 const student: Student = {
    id: "STU-001",
    name:"Hana Tadesse",
    enrollmentDate:Temporal.Now.instant(),
 };

//student.id = "STU-999";
console.log(student.gpa?.toFixed(2));
console.log(student.gpa?.toFixed(2) ?? "Not Yet graded");

function processStudent(raw: unknown)
{
    if(isStudent(raw))
    {
    const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
    console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
    }
    else
    {
        console.error("invalid student data received");
    }
}

// processStudent({id:"STU-001",name:"Hana",gpa:3.7});

// processStudent(42);

//  console.log(parseStudent({id:"STU-001",name:"Hana"}));

// parseStudent({id:42,name:"Test"});




const quiz: AssessmentItem = {
id: "QUIZ-001",
kind: "quiz",
title: "SQL Basics",
correctAnswer: 8,
totalQuestions: 10,
};
const lab: AssessmentItem = {
id: "LAB-001",
kind: "lab",
title: "REST API Project",
functionalityScore: 85,
codeQualityScore: 90,
};
console.log(`Quiz grade: ${calculateGrade(quiz)}%`); // 80
console.log(`Lab grade: ${calculateGrade(lab)}%`); // 87



const pending: EnrollmentStatus = {
status: "PENDING",
requestedAt: Temporal.Now.instant(),
studentId: "STU-001",
courseId: "CRS-101",
};
console.log(describeEnrollment(pending));


const webDev: CourseStatus = {
status: "ACTIVE",
enrolledCount: 28,
startDate: Temporal.PlainDate.from("2026-09-01"),
};

console.log(describeCourse(webDev));