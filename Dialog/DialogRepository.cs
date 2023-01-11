
using System.Collections.Generic;

public static class DialogRepository
{
    private static Dialog[] _dialogs;

    private static Dictionary<int, string> _dialogScenarios = new Dictionary<int, string>()
    {
        {1, "Dialogs_V1" },
        {2, "Dialogs_V2" },
    };

    public static Dialog GetDialogByTitle(string title)
    {
        if (_dialogs == null)
            _dialogs = JsonMaster.ParseResource<Dialog>(_dialogScenarios[1]).ToArray();

        Dialog targetDialog = new Dialog();

        foreach (Dialog dialog in _dialogs)
        {
            if (dialog._title == title)
                targetDialog = dialog;
        }

        return targetDialog;
    }
}
