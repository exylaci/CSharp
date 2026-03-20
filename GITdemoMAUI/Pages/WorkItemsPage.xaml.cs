using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GITdemoMAUI.Models;
using GITdemoMAUI.ViewModels;

namespace GITdemoMAUI.Pages;

public partial class WorkItemsPage : ContentPage
{
    public WorkItemsPage(WorkItemsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }


    //Mivel a swipe view modul gyárilag hibásan működik, ez a programrész ezt a hibát hidalja át, nagyon függ a UI megvalósításától. Nem része a mi logikánkak, hanem magának a swipe view mwgvalósításnak a része. Ezért kerülhet ide a code behind részbe. Ha (egyszer majd) kijavítják a hibát, ez a rész is törölhető lesz.
    //Nem MVVM megoldás, de a swipe view androidon bugos működése miatt muszáj

    private void OnSwipeStarted(object? sender, SwipeStartedEventArgs e)
    {
        if (BindingContext is WorkItemsViewModel viewModel) //Mindig ellenőrizzük, hogy a megfelelő bindincontextben vagyunk-e!
        {
            viewModel.IsSwipping = true;
        }
    }

    private void OnSwipeEnded(object? sender, SwipeEndedEventArgs e)
    {
        if (BindingContext is WorkItemsViewModel viewModel)
        {
            viewModel.IsSwipping = false;
        }
    }

    private void OnEditInvoked(object? sender, EventArgs e)
    {
        if (BindingContext is WorkItemsViewModel viewModel &&
            sender is SwipeItem si &&
            si.BindingContext is WorkItem item)
        {
            if (viewModel.IsBusy)
            {
                return;
            }

            viewModel.ModifyItemCommand.Execute(item);
        }
    }

    private void OnDeleteInvoked(object? sender, EventArgs e)
    {
        if (BindingContext is WorkItemsViewModel viewModel &&
            sender is SwipeItem si &&
            si.BindingContext is WorkItem item)
        {
            if (viewModel.IsBusy)
            {
                return;
            }

            viewModel.DeleteItemCommand.Execute(item);
        }
    }

    private void OnItemTapped(object? sender, TappedEventArgs e)
    {
        if (BindingContext is not WorkItemsViewModel vm)
        {
            return;
        }

        if (vm.IsBusy)
        {
            return;
        }

        if (sender is not BindableObject bo || bo.BindingContext is not WorkItem item)
        {
            return;
        }

        vm.OpenItemCommand.Execute(item);
    }
}