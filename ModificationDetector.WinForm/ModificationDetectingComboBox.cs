using System;
using System.Windows.Forms;

namespace ModificationDetector.WinForm
{
    public class ModificationDetectingComboBox : ComboBox, IModificationDetectingControl
    {
        public object InitialSelectedValue => OrigValue;

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

            OrigValue = SelectedValue;
            ExactlyModified = false;

            SelectedValueChanged += OnSelectedValueChanged;

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
                OrigValue = SelectedValue;
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

            SelectedValueChanged -= OnSelectedValueChanged;

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

            SelectedValue = InitialSelectedValue;
        }

        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            if (!IsModificationDetecting)
            {
                return;
            }

            var modified = !(OrigValue?.Equals(SelectedValue) ?? OrigValue is null);

            if (ExactlyModified.Value != modified)
            {
                ExactlyModified = modified;

                ExactlyModifiedChanged?.Invoke(sender, new ExactlyModifiedChangedEventArgs(modified));
            }
        }
    }
}
