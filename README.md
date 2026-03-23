https://roadmap.sh/projects/task-tracker
# 🧾 Task Tracker CLI

A simple command-line application to manage tasks efficiently from your terminal.

It allows you to create, update, delete, and list tasks, as well as track their status (*todo*, *in-progress*, *done*).

---

## 🚀 Installation

Clone the repository:

```bash
git clone https://github.com/LichDDev/Task-Tracker.git
cd Task-Tracker
```

▶️ Running the Application

All commands must be executed using:
```bash
dotnet run -- <command>
```
The -- ensures arguments are passed directly to the application instead of being interpreted by .NET.

⚙️ Usage
➕ Add a new task
```bash
dotnet run -- add "Buy groceries"
```
Output:

Task added successfully (ID: 1)

✏️ Update a task
```bash
dotnet run -- update 1 "Buy groceries and cook dinner"
```
❌ Delete a task
```bash
dotnet run -- delete 1
```
🔄 Mark a task as in progress
```bash
dotnet run -- mark-in-progress 1
```
✅ Mark a task as done
```bash
dotnet run -- mark-done 1
```
📋 List all tasks
```bash
dotnet run -- list
```
🔍 Filter tasks by status
```bash
dotnet run -- list done
dotnet run -- list todo
dotnet run -- list in-progress
```
🧠 Task Statuses
todo → pending task
in-progress → task in progress
done → completed task

🧪 Example Workflow
```bash
dotnet run -- add "Learn C#"
dotnet run -- add "Build CLI project"

dotnet run -- list

dotnet run -- mark-in-progress 1
dotnet run -- mark-done 1

dotnet run -- list done
```
