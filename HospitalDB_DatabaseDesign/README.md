# The Hospital Administrator’s Database

## Project Description

This project's goal was to  explore the design process for a database that satisfies the requirements described in the narrative provided below. The design was made using Microsoft Visio, and the database was built in Microsoft SQL Server and populated with artificial data. The project also explored creating indexes, check constraints, and similar design concepts. Finally, SQL Server Data Tools and Reporting Services were used to create reports.

## Narrative
The hospital administrator wants to create a database to track nurse assignments to their wards and nurse interactions with their patients, patient admissions by their doctors and treatments administered by doctors to their patients, bed assignments for each patient and items charged to patients during their stay.  Administrator wants to record each nurse’s name and address, phone and alternate phone, email and the medical specialties he or she is certified.  Some nurses supervise one or more other nurses.  No nurse is supervised by more than one nurse, and some nurses are unsupervised.

Each ward at the hospital has a designated number, descriptive name, physical location and phone number. Each ward has at least one nurse assigned to it.  A nurse is assigned to at least one ward and rotates assignments among other wards.  The assignment is tracked by the specific date and the hours worked in the assigned ward by each nurse on that date.

n addition to nurse assignments, each ward also has a charge nurse.  The charge nurse is the custodian of the medical records for the ward.  Not all nurses act in this capacity, but those that do are in charge of only one ward, and a ward only has one charge nurse. A ward consists of hospital beds. The beds are inventoried to a specific ward.  Information on beds including their size (small, large, extra-large) and their type (elevated electrically or manually).  Most of the beds are large and manual (this is the default setting).When a patient is admitted to the hospital they are assigned to a specific bed. Not all beds are available for use all the time, and a bed may not be assigned to more than one patient.Information on patients is recorded: name, gender, dob, address, phone, alternate phone, email.  

The date the patient is admitted to the hospital, the admitting doctor, the date the patient is discharged, and discharging doctor are also tracked.  Some doctors admit patients while others do not.  Doctor information tracked: name, address, phone, alternate phone, email and their medical specialties.The hospital tracks the treatments administered to patients and the treating doctor. Treatments are tracked by name, description, and charge. The hospital also tracks the date and time of each treatment administered and the results.  Some doctors treat patients while others do not.  

A given patient may receive no treatments or may receive many, and some patients may receive their treatments from more than one doctor.  Some treatments have yet to be used while others have been used often.In addition to treatments, patients incur other charges for items used during their stay.  The hospital tracks these charges as “items” and stores information on what items have been charged 
to which patients, based on date and quantity.  Information that is to be stored for each item includes the item name and charge.  All patients incur at least one charge for consumable items used during their stay. Some items are used often while items may be new or unusual in nature and might rarely or never be charged to any patients.

Lastly, the hospital tracks nurse patient care. Each nurse patient care interaction is an event. There are several types of events: wellness check, medication, food service, assistance, treatment admin, and “other.” Given the number of shifts and ward rotations, a patient will typically be seen by more than one nurse during their stay, and a nurse most likely will interact with the same patient over several events during a single shift.

The administrator runs the following reports:

1. Daily report of beds assigned and beds available.
2. Weekly report of patients admitted and discharged, sorted by age.
3. Monthly report of physician admits. 
4. Shift Rotation report of nurse patient care.
5. Summary of charges for a patient stay. 
6. Ward scheduling report with name of charge nurse. 
7. Patient ward assignment report. 
8. Patient treatment report with and without treating physician.

9. Physician treatment report of dates and types of treatments. 

10.Report of Physicians and their specialties.

11.Report of Nurses with their certifications and ward assignments, including those who supervise. 
