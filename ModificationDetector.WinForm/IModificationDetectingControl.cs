using System;

namespace ModificationDetector.WinForm
{
    public interface IModificationDetectingControl
    {
        /// <summary>
        /// 監視状態の間に変更が行われた場合はtrue、未変更の場合はfalse、監視状態でない場合はnull
        /// </summary>
        bool? ExactlyModified { get; }
        /// <summary>
        /// ExactlyModifiedの値が変化した際に発生するイベント
        /// </summary>
        event EventHandler<ExactlyModifiedChangedEventArgs> ExactlyModifiedChanged;
        /// <summary>
        /// 監視状態の場合はtrue、非監視状態の場合はfalse
        /// </summary>
        bool IsModificationDetecting { get; }
        /// <summary>
        /// IsModificationDetectingの値が変化した際に発生するイベント
        /// </summary>
        event EventHandler<IsModificationDetectingChangedEventArgs> IsModificationDetectingChanged;
        /// <summary>
        /// 監視状態に移行した時点での監視対象の値
        /// </summary>
        object OrigValue { get; }
        /// <summary>
        /// 監視状態に移行する。必ずIsModificationDetectingChangedイベントおよびExactlyModifiedイベントが発生する。
        /// </summary>
        void StartModificationDetecting();
        /// <summary>
        /// 監視状態に移行した時点での監視状態の値を再設定する。ExactlyModifiedイベントが発生する場合がある。
        /// </summary>
        void RestartModificationDetecting();
        /// <summary>
        /// 監視状態を解除する。必ずExactlyModifiedイベントおよびIsModificationDetectingChangedイベントが発生する。
        /// </summary>
        void StopModificationDetecting();
        /// <summary>
        /// 監視対象を監視状態に移行した時点の値に戻す。ExactlyModifiedイベントが発生する場合がある。
        /// </summary>
        void Restore();
    }

    public class ExactlyModifiedChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 変化「後」のExactlyModifiedプロパティの値
        /// </summary>
        public bool? ExactlyModified { get; private set; }

        public ExactlyModifiedChangedEventArgs(bool? exactlyModified)
            => ExactlyModified = exactlyModified;
    }

    public class IsModificationDetectingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 変化「後」のIsModificationDetectingプロパティの値
        /// </summary>
        public bool IsModificationDetecting { get; private set; }

        public IsModificationDetectingChangedEventArgs(bool isModificationDetecting)
            => IsModificationDetecting = isModificationDetecting;
    }
}
