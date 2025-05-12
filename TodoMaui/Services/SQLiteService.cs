using SQLite;
using TodoMaui.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoMaui.Services
{
    public class SQLiteService
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "todo.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskItem>().Wait();
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _database.Table<TaskItem>().ToListAsync();
        }

        public async Task<int> SaveTaskAsync(TaskItem task)
        {
            if (task.Id == 0)
                return await _database.InsertAsync(task);
            else
                return await _database.UpdateAsync(task);
        }

        public async Task<int> DeleteTaskAsync(TaskItem task)
        {
            return await _database.DeleteAsync(task);
        }
    }
} 