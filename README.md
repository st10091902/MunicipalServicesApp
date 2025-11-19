# Municipal Services Application

**Student:** Marco Thomas Marais (ST10091902)  
**Module:** PROG7312 — Programming 3B  
**Target:** Windows desktop (WinForms), .NET Framework 4.8, C# 7.3–compatible

This repository contains a municipal desktop app implemented in two parts:
- **Part 1:** Report Issues — capture Location, Category, Description, and optional Attachments with a progress bar and micro-feedback.
- **Part 2:** Local Events & Announcements — search by Category/Date/Keyword, announcements queue, recommendations, and priority highlights.

---

## Prerequisites
- Windows 10/11
- Visual Studio 2022 (or 2019) with .NET Framework 4.8 Developer Pack
- Recommended workload: “.NET desktop development”
- (Optional) Git for version control

> Language version: Code is C# 7.3–compatible. If you turn on newer syntax, set **Project → Properties → Build → Advanced… → Language version = C# 8.0 or Latest**.

---

## Build
1) Open `MunicipalServicesApp.sln` in Visual Studio.  
2) Project → **Properties** → **Application** → confirm **Target Framework = .NET Framework 4.8**.  
3) **Build → Build Solution** (Ctrl+Shift+B).

---

## Run
- Press **F5** (Debug) or **Ctrl+F5** (Run without debugging).  
- The **Main Menu** opens centered on screen.

---

## Part 1 — Report Issues

### Tech Stack
- C# / .NET Framework 4.8
- Windows Forms (WinForms)

### Use
1) Click **Report Issues** on the main menu.  
2) Enter **Location** (street/landmark).  
3) Select **Category** (Sanitation, Roads, Water & Utilities, Electricity, Public Safety, Other).  
4) Describe the issue in **Description**.  
5) (Optional) Add **Attachment(s)** (images/files).  
6) Watch the **Progress bar** and helper text update as you complete fields.  
7) Click **Submit** — a confirmation is displayed.  
   - **Note:** Part 1 stores data **in-memory** only (no DB yet).

---

## Part 2 — Local Events & Announcements

### Tech Stack
- C# / .NET Framework 4.8
- Windows Forms (WinForms)

### Use
1) Click **Local Events & Announcements** on the main menu.  
2) Choose **Category** (or **(All)**), set **From/To** dates, and optionally enter a **Keyword**.  
3) Click **Search** — results appear with **Date, Title, Category, Location, Priority**.  
4) **Announcements:** click **Show Next** to view the next notice (FIFO queue).  
5) **Recommendations:** after a few searches, see suggestions in the **Recommended** panel based on frequent keywords.  
6) A status bar at the bottom displays feedback (e.g., “7 item(s) found”).  
   - Keyboard tip: **Enter** triggers **Search**.

---

## Solution Structure (where things are)

```text
MunicipalServicesApp/
├─ Program.cs                         # App entry
├─ MainForm.cs                        # Main menu
├─ ReportIssueForm.cs                 # Part 1 form
├─ EventsForm.cs                      # Part 2 form (code-behind)
├─ EventsForm.Designer.cs             # Part 2 layout
├─ UI/
│  └─ Theme.cs                        # Consistent fonts/colors/spacing + status bar
├─ Models/
│  ├─ Issue.cs                        # Part 1 Issue model
│  ├─ Attachment.cs                   # Part 1 attachments
│  ├─ IssueCategory.cs                # Part 1 categories
│  └─ EventItem.cs                    # Part 2 event/announcement model + EventPriority
├─ Data/
│  ├─ IssueRepository.cs              # In-memory store for Part 1
│  ├─ EventsRepository.cs             # Dictionaries/Sets/Queue for Part 2
│  └─ EventPriorityQueue.cs           # Binary heap (priority queue) for top notices
└─ Seed.cs                            # Seeds demo events/announcements on first open
```
---

## Data Structures (where used)
- **Dictionary<string, List<EventItem>>** — category index (hash table) → `Data/EventsRepository.cs`  
- **SortedDictionary<DateTime, List<EventItem>>** — date buckets for range queries → `Data/EventsRepository.cs`  
- **HashSet<string>** — unique category list → `Data/EventsRepository.cs`  
- **Queue<EventItem>** — announcements FIFO → `Data/EventsRepository.cs`, `EventsForm.cs`  
- **Stack<string>** — user search history (latest first) → `EventsForm.cs`  
- **EventPriorityQueue** (binary heap) — top/high-priority notices → `Data/EventPriorityQueue.cs`  
- **List<Issue>** — in-memory issues store (Part 1) → `Data/IssueRepository.cs`

**Recommendations:** each search updates `SearchKeywordCounts` (`Dictionary<string,int>`). The Recommended panel uses top keywords to suggest upcoming events.

---

## Testing & Verification Checklist
- **Part 1**
  - Progress bar increments for Location, Category, Description.
  - Attachments list shows selected files.
  - Submit validates required fields; success dialog appears.
  - (Optional) Show in-memory count after submit.
- **Part 2**
  - `Seed.Load()` runs on first open (categories > 0).
  - Category and date filters adjust results correctly.
  - Keyword finds matches in Title/Description/Location.
  - **Show Next** dequeues announcements and updates the list.
  - **Recommended** panel updates after a few searches.
  - Status bar shows “X item(s) found”.

---

## Troubleshooting
- **CS8370 / newer C# features error:** set **Language version = C# 8.0 or Latest** (Project → Properties → Build → Advanced…) or keep the included C# 7.3-compatible code (classic `using (...) { }`, explicit `new List<T>()`, `if/else` instead of switch expressions).
- **Events form doesn’t open:** ensure in `MainForm.cs`:
  ```csharp
  btnEvents.Enabled = true;
  btnEvents.Click += new System.EventHandler(this.btnEvents_Click);

  private void btnEvents_Click(object sender, EventArgs e)
  {
      Seed.Load();
      using (var dlg = new EventsForm())
      {
          dlg.ShowDialog(this);
      }
  }
'''
# Part 3 — Service Request Status

## Tech Stack
- C# / .NET Framework 4.8 · WinForms

## Run
Main Menu → **Service Request Status**.

## Use
- **Find**: enter a **Request #** or a **keyword** and click **Find**.  
- **Advance Status**: steps a request through Received → InQueue → Assigned → Resolved.  
- **Suggest Assignment**: chooses the next request by **min-heap** (lower ETA first, tie-break by higher Priority).  
- **Nearest Depot**: uses a **graph + BFS** from the request’s ward to the closest depot.  
- **MST Weight**: shows total cost of a **minimum spanning tree** across the ward network.

## Data Structures used
- **BST (custom)** → `RequestNo → ServiceRequest` (fast numeric lookup).  
- **AVL (custom)** → `keyword → {requestNos}` (balanced keyword index).  
- **SortedDictionary<DateTime, List<ServiceRequest>** (RB-tree) → index by Created date.  
- **Min-Heap (custom)** → scheduling by `ETA` then `Priority`.  
- **Graph + BFS** → nearest depot to a ward.  
- **Prim MST** → minimal total connection weight across wards.

## Files
- `Data/RequestRepository.cs` · `Models/ServiceRequest.cs`  
- `Data/Structures/BstByRequestNo.cs` · `AvlKeywordIndex.cs` · `MinHeap.cs` · `Graph.cs`  
- `Data/CityGraph.cs` (ward/depot network) · `Seed.cs` (`LoadRequests()`)  
- `StatusForm.cs` / `StatusForm.Designer.cs`

# Implementation Report — Service Request Status (Task 3)

## How to Compile and Run
1. Open `MunicipalServicesApp.sln` in Visual Studio 2022 (or 2019 with .NET 4.8 dev pack).
2. Project → Properties → **Target Framework = .NET Framework 4.8**.
3. Build → **Build Solution**; Run with **F5**.
4. Main Menu → **Service Request Status**. Seeded demo data is loaded automatically (`Seed.LoadRequests()`).

## Feature Overview
- **Grid view** lists requests (No, Title, Category, Ward, Priority, ETA, Status, Created).
- **Find** accepts a numeric Request # (BST) or a free-text keyword (AVL).
- **Advance Status** transitions the workflow: Received → InQueue → Assigned → Resolved.
- **Suggest Assignment** uses a **min-heap** (ETA ↑, tie → Priority ↓) to pick the next job.
- **Nearest Depot** performs **BFS** across wards/depots to find the closest depot to the request’s ward.
- **MST Weight** runs **Prim** to calculate a minimum spanning tree total weight for the ward network.

## Data Structures and Their Contribution

### 1) Binary Search Tree (BST) — `BstByRequestNo`
- **Purpose:** O(log n) lookup by numeric `RequestNo`.
- **Where used:** `RequestRepository.Bst.Find(no)` inside **Find**.
- **Why it helps:** Immediate retrieval without scanning the list; scales as requests grow.

### 2) AVL Tree — `AvlKeywordIndex`
- **Purpose:** Balanced index mapping **keyword → set(requestNos)**.
- **Where used:** keyword branch in **Find**; results are joined to requests.
- **Why it helps:** Ensures O(log n) updates/lookups even as vocabulary expands; robust under skewed input.

### 3) Red-Black Tree (via `SortedDictionary<DateTime, List<ServiceRequest>>`)
- **Purpose:** Maintain requests sorted by Created date.
- **Where used:** `RequestRepository.ByDate` (indexing & potential date-range operations).
- **Why it helps:** Ordered iteration/range queries with balanced-tree guarantees.

### 4) Min-Heap — `MinHeap`
- **Purpose:** Choose the “next assignment” by minimum **ETA** (then higher **Priority**).
- **Where used:** **Suggest Assignment** pops the heap’s root.
- **Why it helps:** O(log n) insert/pop vs O(n) scans; perfect for dispatch queues.

### 5) Graph + BFS — `Graph`, `CityGraph`
- **Purpose:** Model ward/depots network; find **nearest depot**.
- **Where used:** **Nearest Depot** button (`Graph.Nearest`).
- **Why it helps:** BFS finds the shortest path in hop-weighted graphs; quick and demonstrable.

### 6) Minimum Spanning Tree (Prim)
- **Purpose:** Show an optimized connection plan across wards (total weight).
- **Where used:** **MST Weight** button (`Graph.PrimMstWeight`).
- **Why it helps:** Demonstrates graph algorithms beyond shortest path; indicates minimal infrastructure cost.

## Relevant Code Entry Points
- `RequestRepository.Add(...)` — updates **BST, AVL, SortedDictionary, Min-Heap** in one place.
- `StatusForm.BtnFind_Click` — uses **BST/AVL**.
- `StatusForm.BtnSuggest_Click` — uses **Min-Heap**.
- `StatusForm.BtnNearestDepot_Click` — uses **BFS**.
- `StatusForm.BtnMst_Click` — uses **Prim**.

## Example
- Enter keyword **“pothole”** → AVL resolves matching request IDs → grid shows those requests.
- Click **Suggest Assignment** → min-heap returns the job with the smallest ETA (ties broken by higher priority).
- Select a row on **Ward 3** → **Nearest Depot** might return **Depot B** via BFS traversal.
