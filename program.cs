using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWave.Pro
{
    // تعريف الكيان (Entity)
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // مدير المهام (Task Manager) - بيطبق مبدأ الـ Logic Separation
    public class TaskRepository
    {
        private List<ProjectTask> _tasks = new List<ProjectTask>();

        public void AddTask(string title)
        {
            var task = new ProjectTask { Id = _tasks.Count + 1, Title = title, IsCompleted = false };
            _tasks.Add(task);
            Console.WriteLine($"[✓] Task '{title}' added successfully.");
        }

        public void ListTasks()
        {
            Console.WriteLine("\n--- Current Project Tasks ---");
            if (!_tasks.Any()) Console.WriteLine("No tasks available.");
            
            foreach (var task in _tasks)
            {
                string status = task.IsCompleted ? "[Completed]" : "[Pending]";
                Console.WriteLine($"{task.Id}. {task.Title} - {status} (Created: {task.CreatedAt:yyyy-MM-dd})");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CodeWave Task System";
            var repo = new TaskRepository();

            // إضافة بيانات تجريبية
            repo.AddTask("Design Database Schema");
            repo.AddTask("Setup Git Repository");
            repo.AddTask("Develop API Endpoints");

            // عرض القائمة
            repo.ListTasks();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}