using AzureMobileClient.Helpers;
using MonkeyChat.Models;

namespace MonkeyChat.Data
{
    public interface IAppDataContext
    {
        ICloudSyncTable<TodoItem> TodoItems { get; }
        ICloudSyncTable<ChatMessage> ChatMessages { get; }
        ICloudSyncTable<ChatRoom> ChatRooms { get; }
    }
}