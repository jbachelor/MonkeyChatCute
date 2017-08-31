using AzureMobileClient.Helpers;
using MonkeyChat.Helpers;
using MonkeyChat.Models;
using DryIoc;

namespace MonkeyChat.Data
{
    // If you do want to use authentication inherit from DryIocCloudServiceContext
    public class AppDataContext : DryIocCloudAppContext, IAppDataContext
    {
        public AppDataContext(IContainer container) 
            : base(container) // you can optionally pass in the data store name
        {
        }

        // Any ICloudSyncTable's that you have here will be automatically registered with the local store.
        public ICloudSyncTable<TodoItem> TodoItems => SyncTable<TodoItem>();
        public ICloudSyncTable<ChatRoom> ChatRooms => SyncTable<ChatRoom>();
        public ICloudSyncTable<ChatMessage> ChatMessages => SyncTable<ChatMessage>();
    }
}