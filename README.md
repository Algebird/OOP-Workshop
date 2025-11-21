1. Requirements
I) Functional Requirements

1.Support multiple media types: E-Books, Movies, Songs, Video-games, Apps, Podcasts, Images. Each media type stores its specific metadata (title, author/director/composer/etc., language, release/publish year, duration where applicable, file type/format, file size, publisher, ISBN where applicable, supported platforms for video-games and apps, resolution for images, episode number for podcasts, etc.).
2.Allow users to view and preview item details.
3.Allow users to download media items where applicable.
4.Allow users to play media items when applicable (movies, songs, video-games, apps, podcasts) and execute apps.
5.Allow users to borrow and return media items (borrowing applies to items that can be borrowed; UI must make clear which items are borrowable).
6.Allow users to rate items they have borrowed (only borrowers who have borrowed an item may rate it).
7.Provide role-based actions:
	-Borrower: list items by type, select & preview details, rate items, borrow/return items, perform media-type-specific actions (play, download, execute) for allowed items.
	-Employee: add, edit and remove media items; manage metadata; list and view collections.
	-Admin: all Employee rights + manage (create/update/delete) Employee and Borrower user accounts and view system-level management actions.
8.Console interface that guides users with clear instructions and validates all inputs. Errors must not pass validation.
9..Start mode: user authentication is not required, but on startup the program should ask the user to identify their role (Borrower/Employee/Admin).
10.System should support listing, searching and filtering items (by type, title, author/director, language, year, platform, etc.).
11.Data persistence for media collection and user records (file or simple database) across runs.
12.Logging of key actions (add/remove/borrow/return/rate) for audit/debug.
13.Extensibility: design must allow adding new media types and user roles without disrupting existing functionality.

II)Non-functional Requirements

Interface: Console-based, user-friendly prompts and clear validation messages.
Performance: Reasonable response times for listing and searching (acceptable for small-to-medium collections).
Security & Privacy: Store personal details (name, age, social security number) safely; avoid printing SSN in logs or to screen. Limit access to management commands by role.
Maintainability: Modular design, clear separation between domain model, persistence, and UI.
Extensibility: New media types and roles can be added with minimal changes.
Reliability: Correct handling of borrow/return state, preventing double-borrows when not allowed.
Testability: Components should be unit-testable.
Portability: Work on major OS terminals (Windows, macOS, Linux).

2. Verb–Noun Analysis
Verb	Noun(s)	Notes / Comments
view / preview	MediaItem (specific subtype)	show metadata, thumbnail/preview where applicable
list	MediaItem, User	list items by type, list users (Admin/Employee)
download	MediaItem	applies to files; restrictions may apply
play	Movie, Song, VideoGame, Podcast	media playback action
execute	App	run or simulate app execution
add / create	MediaItem, User	Employees add items; Admin can create users
remove / delete	MediaItem, User	Employees delete media; Admin deletes users
update / edit	MediaItem, User	modify metadata or user details
borrow	MediaItem (borrowable)	Borrower action; creates BorrowRecord
return	BorrowRecord / MediaItem	completes borrow cycle
rate	MediaItem	borrower rates an item; creates Rating
manage	Collection / Users	Employee/Admin responsibilities
authenticate / identify role	User	initial identification of role at startup
validate	input	Console UI responsibility
search / filter	MediaItem	query by metadata fields
log	Action	system logging of events
3. CRC (Class-Responsibility-Collaborator) Cards

CRC format: Class — Responsibilities — Collaborators

3.1 MediaItem (abstract)

Responsibilities: store common metadata (title, language, year, publisher, file size, file format); provide preview() and download() behaviors; expose type-specific metadata. Collaborators: EBook, Movie, Song, VideoGame, App, Podcast, Image, Rating, BorrowRecord, Library

3.2 EBook, Movie, Song, VideoGame, App, Podcast, Image (concrete subclasses)

Responsibilities: hold media-type-specific fields (e.g., ISBN for EBook, director for Movie, composer for Song, supportedPlatforms for VideoGame/App, resolution for Image, episode number for Podcast); implement play()/execute() if applicable. Collaborators: MediaItem (base), Library, BorrowRecord, Rating

3.3 User (abstract)

Responsibilities: store personal data (name, age, SSN, role), identify and present allowed actions. Collaborators: Borrower, Employee, Admin, BorrowRecord, Library

3.4 Borrower (subclass of User)

Responsibilities: borrow(), return(), rateItem(), listItems(), previewItem(), downloadItem(), playItem() Collaborators: MediaItem, BorrowRecord, Rating, Library

3.5 Employee (subclass of User)

Responsibilities: addMedia(), removeMedia(), updateMedia(), listItems(), previewItem() Collaborators: MediaItem, Library

3.6 Admin (subclass of Employee)

Responsibilities: manageUsers() (create/update/delete Borrower and Employee), view system logs, full management operations Collaborators: User (Borrower, Employee), Library, Logger

3.7 BorrowRecord

Responsibilities: record borrow transactions (user, mediaItem, borrowDate, dueDate, returnedFlag) Collaborators: Borrower, MediaItem, Library

3.8 Rating

Responsibilities: store and provide ratings and optionally comments (user, mediaItem, score, date) Collaborators: Borrower, MediaItem

3.9 Library / Collection / Catalog

Responsibilities: store all media items; search / filter / list; persist/load data; coordinate add/remove operations Collaborators: MediaItem, User, BorrowRecord, Persistence

3.10 Persistence (Repository)

Responsibilities: save/load media items, users, borrow records and ratings to disk Collaborators: Library, User, BorrowRecord, Rating

3.11 ConsoleInterface

Responsibilities: present menus, validate input, route commands to Library/User operations, ask for role on startup Collaborators: User subclasses, Library, Persistence, AuthenticationManager (optional)
[link](https://www.mermaidchart.com/app/projects/8968cd52-36c1-4d82-a9cf-d3c646a123a2/diagrams/1e78c4c7-ada1-4c8c-94a3-3dd138d46e50/share/invite/eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkb2N1bWVudElEIjoiMWU3OGM0YzctYWRhMS00YzhjLTk0YTMtM2RkMTM4ZDQ2ZTUwIiwiYWNjZXNzIjoiRWRpdCIsImlhdCI6MTc2MzU2NzQ5OX0.OAT1G-Cj-Ge8mn0fam1OzhUoQCGmWEifRxOyp0cxT6I)

UML Diagram:
```mermaid
classDiagram
MediaItem <|-- Podcast
MediaItem <|-- Image


class User {
+String id
+String name
+int age
+String ssn
+getRole()
}
class Borrower {
+borrow(MediaItem)
+return(MediaItem)
+rate(MediaItem, int)
}
class Employee {
+addMedia(MediaItem)
+removeMedia(String id)
+updateMedia(MediaItem)
}
class Admin {
+manageUser(User)
+viewLogs()
}


User <|-- Borrower
User <|-- Employee
Employee <|-- Admin


class BorrowRecord {
+String id
+String userId
+String mediaItemId
+Date borrowDate
+Date dueDate
+Boolean returned
}


class Rating {
+String id
+String userId
+String mediaItemId
+int score
+String comment
}


class Library {
+add(media: MediaItem)
+remove(id: String)
+search(query)
+listByType(type)
}


class Persistence {
+saveAll()
+loadAll()
}


Library "1" -- "*" MediaItem : contains
Borrower "1" -- "*" BorrowRecord : creates
BorrowRecord "*" -- "1" MediaItem : references
Rating "*" -- "1" MediaItem : rates
Rating "*" -- "1" Borrower : by
Library "1" -- "1" Persistence : uses
```