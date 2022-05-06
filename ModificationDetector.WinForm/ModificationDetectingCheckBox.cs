using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModificationDetector.WinForm
{
    public class ModificationDetectingCheckBox : CheckBox, IModificationDetectingControl
    {
        public CheckState? InitialCheckState => (CheckState?)OrigValue;

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

            OrigValue = CheckState;
            ExactlyModified = false;

            CheckStateChanged += OnCheckStateChanged;

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
                OrigValue = CheckState;
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

            CheckStateChanged -= OnCheckStateChanged;

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

            CheckState = InitialCheckState.Value;
        }

        private void OnCheckStateChanged(object sender, EventArgs e)
        {
            if (!IsModificationDetecting)
            {
                return;
            }

            var modified = !(OrigValue?.Equals(CheckState) ?? OrigValue is null);

            if (ExactlyModified.Value != modified)
            {
                ExactlyModified = modified;

                ExactlyModifiedChanged?.Invoke(sender, new ExactlyModifiedChangedEventArgs(modified));
            }
        }
    }
}
