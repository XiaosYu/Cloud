# Database-based online multi-role document submission management system
Author：Jingyu Li [EMail](lijingyu_ai@163.com)
## What's this about?
This is a system for multi-role document submission and management that contains a database as the core of data storage and management. Users can submit documents under different roles and have them approved, modified and reviewed by other roles. The following are the features that the system may include:
<ol>
<li>
Document Submission : Users can submit their documents as per their role needs. For example, a teacher can submit a proposal, a student can submit a thesis; or an administrator can post some collection items and users can submit the corresponding documents or code.
</li>
<li>
Progress Reminders: All different user groups are reminded of the different tasks, the latest submission time and the activity level of the submission. Warnings will be issued when approaching the submission line.
</li>
<li>
Notifications: The system automatically sends notifications to the appropriate people via email, message or other means to ensure they are kept up-to-date on the status of documents and the progress of processing.
</li>
<li>
Security: The system uses security techniques to ensure data privacy, such as access control and authentication.
</li>
<li>
Database Backup: The system performs regular backups of all data and document programmes involved to ensure that they can be recovered in the event of downtime or failure.
</li>
</ol>
This system can be applied to various fields such as academic, corporate, government, etc. By using a database-based multi-role document submission and management system, users can collaborate and complete tasks more effectively and get better productivity.

## Project contents
<ol>
<li>
Role Management: The system will automatically assign different permission levels to users based on their identity so that they can access only the document categories/entries that are relevant to their tasks and control whether submitted documents can be modified, approved, reviewed, etc.
</li>
<li>
Communication pipeline: When a new document is submitted or an old document is updated, the system will notify the relevant personnel through the communication pipeline in a timely manner. For example, sending reminders to the relevant people via email or SMS.
</li>
<li>
Alert system: If a document has been deliberately modified to an excessive extent or is at risk, an alert system needs to be in place so that security issues can be detected and dealt with in a timely manner.
</li>
<li>
Search: Because the system has a large number of documents, a good search box function has been built so that users can quickly find the data they need in the document database.
</li>
<li>
User Interface (UI): In order to ensure sufficient ease of use and operability, the web-side UI is written using the Blazor framework to help users operate more efficiently.
</li>
</ol>

## How to use the program
Configure the **.\Cloud.World\Cloud.World.Server** in the **config.json** file **ConnectionString** configuration for their own database of the same name, the system will automatically generate the corresponding table structure.And Run the program **Cloud.World.Server**

