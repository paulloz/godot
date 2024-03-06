using System.Collections.Generic;
using Godot;

namespace GodotTools
{
    public partial class ListConfirmationDialog : ConfirmationDialog
    {
        private Label _label;
        private Tree _tree;

        public static Texture2D WarningIcon =>
            EditorInterface.Singleton.GetEditorTheme().GetIcon("Warning", "EditorIcons");

        public ListConfirmationDialog()
        {
            var vBox = new VBoxContainer();
            AddChild(vBox);

            _label = new Label();
            _tree = new Tree();

            vBox.AddChild(_label);
            vBox.AddChild(_tree);

            _tree.HideRoot = true;
            _tree.SizeFlagsVertical = Control.SizeFlags.ExpandFill;
        }

        public new string DialogText
        {
            get => _label.Text;
            set => _label.Text = value;
        }

        public void ClearTree()
        {
            _tree.Clear();
            _tree.CreateItem();
        }

        public void CreateItemInTree(string text, Texture2D? icon, int index = -1)
        {
            var item = _tree.CreateItem(null, index);
            item.SetText(0, text);
            item.SetIcon(0, icon);
        }

        public void SetTreeItems(IReadOnlyList<(string Text, Texture2D? Icon)> treeItems)
        {
            ClearTree();
            foreach (var treeItem in treeItems)
            {
                CreateItemInTree(treeItem.Text, treeItem.Icon);
            }
        }
    }
}
