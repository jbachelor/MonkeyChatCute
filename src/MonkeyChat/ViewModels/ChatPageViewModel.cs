using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Navigation;
using Prism.Services;
using MonkeyChat.Strings;
using MonkeyChat.Models;
using Prism.AppModel;
using MvvmHelpers;
using MonkeyChat.Data;
using MonkeyChat.Helpers;

namespace MonkeyChat.ViewModels
{
    public class ChatPageViewModel : ViewModelBase
    {
        IAppDataContext _context { get; }
        public ChatPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                     IDeviceService deviceService, IAppDataContext context)
            : base(navigationService, applicationStore, deviceService)
        {
            _context = context;
            Messages = new ObservableRangeCollection<ChatMessage>();
            RefreshCommand = new DelegateCommand(OnRefreshCommandExecuted, () => IsNotBusy).ObservesProperty(() => IsNotBusy);
            AddMessageCommand = new DelegateCommand(OnAddMessageCommandExecuted);
            AddMessageCompositeCommand = new CompositeCommand();
            AddMessageCompositeCommand.RegisterCommand(AddMessageCommand);
            AddMessageCompositeCommand.RegisterCommand(RefreshCommand);
        }

        public ObservableRangeCollection<ChatMessage> Messages { get; set; }

        public string Text { get; set; }

        public DelegateCommand AddMessageCommand { get; }

        public DelegateCommand RefreshCommand { get; }

        public CompositeCommand AddMessageCompositeCommand { get; }

        public ChatRoom Room { get; set; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            Room = parameters.GetValue<ChatRoom>("room")?? new ChatRoom{ Name = "default"};
            Title = Room.Name;
            OnRefreshCommandExecuted();
        }

        private async void OnRefreshCommandExecuted()
        {
            IsBusy = true;
            //TODO: Get the latest messages
            Messages.ReplaceRange(await _context.ChatMessages.ReadAllItemsAsync());
            IsBusy = false;
        }

        private async void OnAddMessageCommandExecuted()
        {
            IsBusy = true;

            //TODO: Create a message
            var message = new ChatMessage { Message = Text, FromEmail = "default@example.org" };
            await _context.ChatMessages.CreateItemAsync(message);
            //TODO: Check for new msgs
            //Messages.Add(message);
            Text = string.Empty;
            IsBusy = false;
        }
    }
}