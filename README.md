SmartHealthCare

Backend implementation of the Smart Healthcare Appointment and Prescription Management System with Integrated Patient Support Services — a Postgraduate Diploma (PGD) research project.

This repository contains the working backend built to validate the conceptual design and system architecture presented in the accompanying thesis (Chapter Three: Methodology). It is a reference implementation accompanying a conceptual research framework; scenario-based performance figures reported in the thesis remain literature-derived projections and have not been empirically measured against this implementation.

Overview

The system addresses three core problems in fragmented, manual healthcare administration:


Appointment Management — real-time slot availability, booking, cancellation, and rescheduling
Electronic Prescription Management — prescription issuance with a three-tier (Green / Amber / Red) Clinical Decision Support System (CDSS) check for drug interactions and allergy contraindications
Patient Support Notifications — automated, multi-channel (SMS, email, in-app) notification dispatch with bounded retry logic


Tech Stack

LayerTechnologyFrameworkABP.io v9.2.0Backend runtimeASP.NET Core 8DatabaseMySQL 8.0ORMEntity Framework Core (Pomelo MySQL provider)Background jobsHangfireAuthABP Identity + OpenIddict (JWT bearer tokens)

Generated from the ABP CLI template:

bashabp new SmartHealthCare -t app -u angular -m none --database-provider ef --database-management-system MySQL -csf --version 9.2.0 --old


Note: this repository currently contains the backend only. The Angular client scaffolded by -u angular is not yet implemented.



Architecture

The solution follows ABP.io's layered Clean Architecture:

SmartHealthCare.Domain.Shared       Enums and constants (AppointmentStatus, InteractionLevel, NotificationChannel, ...)
SmartHealthCare.Domain              Entities, aggregate roots, domain services (AppointmentManager, PrescriptionManager, CDSS logic)
SmartHealthCare.Application.Contracts   DTOs, application service interfaces, permission definitions
SmartHealthCare.Application         Application service implementations
SmartHealthCare.EntityFrameworkCore  DbContext, EF Core mappings, repository implementations
SmartHealthCare.HttpApi             REST controllers
SmartHealthCare.HttpApi.Host        Web host, startup configuration, Hangfire job registration
SmartHealthCare.DbMigrator          Database migration / seed console app

Each functional area (Appointments, Prescriptions, Notifications) is organised as a feature folder/namespace within these layers rather than as a separate ABP module.

Entity Relationship Diagram

See docs/erd.png (or Chapter Three, Section 3.7.3 of the thesis) for the full schema: Patients, Doctors, Appointments, Prescriptions, PrescriptionItems, DrugInteractionLogs, Notifications, linked to ABP Identity's AbpUsers.

System Flowchart

See docs/flowchart.png (or Chapter Three, Section 3.7.4 of the thesis) for the end-to-end program logic: login → role routing → appointment booking / e-prescription issuance with CDSS check / pharmacy dispensing → notification dispatch.

Key Domain Logic

CDSS Drug Interaction Check (PrescriptionManager.CheckNewItemAsync)

Every new prescription item is checked against the patient's existing active medications and recorded allergies via ICdssService. Each check returns one of three interaction levels:

LevelMeaningEffect on IssueAsyncGreenNo known interactionPrescription proceeds normallyAmberModerate interaction — requires physician acknowledgementBlocked until the item ID is included in acknowledgedItemIdsRedCritical contraindicationAlways blocked — cannot be overridden

Notification Dispatch (NotificationDispatchJob)

A recurring Hangfire job polls for due, pending notifications, resolves the correct INotificationSender for the channel (SMS / Email / In-App), and on failure re-queues with a 30-minute delay, up to 3 retry attempts, before marking the notification as permanently failed.

API Reference

All endpoints require a Bearer JWT obtained via POST /connect/token (ABP Identity / OpenIddict).

Appointments — /api/app/appointments

MethodRouteDescriptionGET/api/app/appointmentsPaged list (filter: doctorId, patientId, status, date)GET/api/app/appointments/{id}Get a single appointmentPOST/api/app/appointmentsBook a new appointmentPUT/api/app/appointments/{id}RescheduleDELETE/api/app/appointments/{id}Soft-deleteGET/api/app/appointments/available-slots30-minute slots, 08:00–17:00POST/api/app/appointments/{id}/cancelCancel with reasonPOST/api/app/appointments/{id}/completeMark completedGET/api/app/appointments/my-appointmentsCurrent patient's appointments

Prescriptions — /api/app/prescriptions

MethodRouteDescriptionGET/api/app/prescriptions/{id}Get prescription with itemsGET/api/app/prescriptionsPaged list (filter: patientId, doctorId, status)POST/api/app/prescriptionsCreate draft + run CDSS checkPOST/api/app/prescriptions/check-interactionsLive-validate without persistingPOST/api/app/prescriptions/{id}/issueSign and issue (blocks on Red, requires override on Amber)POST/api/app/prescriptions/{id}/dispensePharmacist marks dispensedPOST/api/app/prescriptions/{id}/cancelCancel

Notifications — /api/app/notifications

MethodRouteDescriptionGET/api/app/notificationsAdmin/staff paged viewGET/api/app/notifications/my-notificationsCurrent patient's notification history

Getting Started

Prerequisites


.NET 9 SDK
MySQL 8.0
ABP CLI (dotnet tool install -g Volo.Abp.Cli)
Node.js (only required if/when the Angular client is added)


Setup


Clone the repository


bash   git clone <this-repository-url>
   cd SmartHealthCare


Configure the connection string
Update ConnectionStrings:Default in:

src/SmartHealthCare.HttpApi.Host/appsettings.json
src/SmartHealthCare.DbMigrator/appsettings.json





json   {
     "ConnectionStrings": {
       "Default": "Server=localhost;Port=3306;Database=SmartHealthCare;Uid=root;Pwd=YOUR_PASSWORD;"
     }
   }


Restore dependencies


bash   dotnet restore
   abp install-libs


Apply database migrations and seed data


bash   cd src/SmartHealthCare.DbMigrator
   dotnet run


Run the API host


bash   cd src/SmartHealthCare.HttpApi.Host
   dotnet run


Explore the API
Navigate to https://localhost:<port>/swagger for the interactive Swagger UI once the host is running.


Project Status

This is an academic reference implementation developed alongside a PGD research project. It demonstrates the technical feasibility of the proposed conceptual design but has not undergone production hardening, load testing, or clinical validation. See the accompanying thesis (Chapter Four, Section 4.7) for documented implementation challenges and recommended next steps.
