# Bug Tracker Pro
A desktop bug tracking application built with C# WinForms and SQLite.It`s a simple app,for a simple student like me :).
The app helps users manage software bugs through a simple interface with CRUD operations, search, sorting, status tracking, statistics, and CSV export.

## Overview
I built Bug Tracker Pro as a portfolio project to practice desktop application development in C#.
The application allows users to create, edit, delete, search, sort, and export bug reports. Data is stored locally using an SQLite database, so bugs remain saved between sessions,which gave me to some extent headaches :)).
The project focuses on both functionality and user experience, using a somewhat styled WinForms interface with color-coded severity/status indicators and a small statistics dashboard.

## Features
* Add new bug reports
* Edit existing bugs by double-clicking a row
* Delete bugs with confirmation
* Update bug status:
  * Open
  * In Progress
  * Closed
* Real-time search by title, description, severity, or status
* Sort bugs by severity
* Sort bugs by status
* SQLite database persistence
* Statistics dashboard
* Color-coded severity and status fields
* CSV export
* Empty-state message when no bugs are found
* Styled WinForms interface with custom buttons and hover effects

## Technologies Used
* C#
* Windows Forms
* SQLite
* .NET Framework
* Visual Studio

## Database
The application uses a local SQLite database called `bugs.db`.

The main table stores:

| Field       | Description                            |
| ----------- | -------------------------------------- |
| Id          | Unique bug identifier                  |
| Title       | Bug title                              |
| Description | Bug description                        |
| Severity    | Low, Medium, or High                   |
| Status      | Open, In Progress, or Closed           |
| CreatedAt   | Date and time when the bug was created |

## Skills Demonstrated
This project demonstrates:
* Object-Oriented Programming
* CRUD operations
* SQLite database integration
* Event-driven programming
* Data filtering and sorting
* WinForms UI customization
* CSV file export
* Basic software project organization


Possible future improvements:
* Advanced filtering
* Priority levels
* Due dates
* User assignment
* Charts for statistics
* Improved add/edit form design

## Author

Linta Vincent Alexander as a C# WinForms portfolio project for internship applications.

Hope you have a fantastic day,thank you for reading!
