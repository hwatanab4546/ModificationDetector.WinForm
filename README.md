
# ModificationDetector.WinForm

あらかじめ登録しておいたプロパティの値が変更されたことを検出することを目的としたライブラリです。

## 特徴

- 任意の時点を初期状態として、変更監視を開始することができます。
- 初期状態を復元することが可能です。

## 使用方法

- 同封のサンプルプロジェクト(ModificationDetector.WinForm.Sample)を参考にしてください。

## 備考

- .NET Framework 4.7.2で作成しています。
- 今のところTextBox, ComboBox, CheckBoxの3コントロールのみを対象としていますが、今後、他のコントロールが必要になれば追加するかもしれません。
- サンプルプロジェクトでRxを使用していますが、必須というわけではありません。
