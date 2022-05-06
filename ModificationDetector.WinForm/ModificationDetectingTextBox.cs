using System;
using System.Windows.Forms;

namespace ModificationDetector.WinForm
{
    public class ModificationDetectingTextBox : TextBox, IModificationDetectingControl
    {
        public string InitialText => (string)OrigValue;

        public bool? ExactlyModified { get; private set; } = null;
        public event EventHandler<ExactlyModifiedChangedEventArgs> ExactlyModifiedChanged;

        public bool IsModificationDetecting => ExactlyModified.HasValue;
        public event EventHandler<IsModificationDetectingChangedEventArgs> IsModificationDetectingChanged;

        public object OrigValue { get; private set; } = null;

        public void StartModificationDetecting()
        {
            if (IsModificationDetecting)
            {
                throw new InvalidOperationException();
            }

            OrigValue = Text;
            ExactlyModified = false;

            TextChanged += OnTextChanged;

            IsModificationDetectingChanged?.Invoke(this, new IsModificationDetectingChangedEventArgs(true));
            ExactlyModifiedChanged?.Invoke(this, new ExactlyModifiedChangedEventArgs(false));
        }
        public void RestartModificationDetecting()
        {
            if (!IsModificationDetecting)
            {
                throw new InvalidOperationException();
            }

            if (ExactlyModified.Value)
            {
                OrigValue = Text;
                ExactlyModified = false;

                ExactlyModifiedChanged?.Invoke(this, new ExactlyModifiedChangedEventArgs(false));
            }
        }
        public void StopModificationDetecting()
        {
            if (!IsModificationDetecting)
            {
                throw new InvalidOperationException();
            }

            TextChanged -= OnTextChanged;

            OrigValue = null;
            ExactlyModified = null;

            ExactlyModifiedChanged?.Invoke(this, new ExactlyModifiedChangedEventArgs(null));
            IsModificationDetectingChanged?.Invoke(this, new IsModificationDetectingChangedEventArgs(false));
        }
        public void Restore()
        {
            if (!IsModificationDetecting)
            {
                throw new InvalidOperationException();
            }

            Text = InitialText;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!IsModificationDetecting)
            {
                return;
            }

            var modified = !(OrigValue?.Equals(Text) ?? OrigValue is null);

            if (ExactlyModified.Value != modified)
            {
                ExactlyModified = modified;

                ExactlyModifiedChanged?.Invoke(sender, new ExactlyModifiedChangedEventArgs(modified));
            }
        }
    }
}
