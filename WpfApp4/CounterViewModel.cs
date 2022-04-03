using System.Collections.Generic;
using System.ComponentModel;
using WpfApp4.Models;
using WpfApp4.Commands;

namespace WpfApp4
{
    public class CounterViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// View Modelのルールとして実装しておくイベントハンドラ
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        //Modelのインスタンスを保持するプロパティ
        public List<NumberWithError> Numbers { get; set; }

        /// <summary>
        /// コマンドを格納するプロパティ
        /// </summary>
        public AddCommnad AddCommnad_ { get; init; }
        public SubCommnad SubCommnad_ { get; init; }
        public MulCommnad MulCommnad_ { get; init; }
        public DivCommnad DivCommnad_ { get; init; }
        public PasteResultCommand PasteResultCommand_ { get; init; }

        /// <summary>
        /// コンストラクタ
        /// ここでコマンドのインスタンスを生成し、プロパティに格納しておく
        /// </summary>
        public CounterViewModel()
        {
            //CountDownCommand = new CountDownCommand(this);
            AddCommnad_ = new AddCommnad(this);
            SubCommnad_ = new SubCommnad(this);
            MulCommnad_ = new MulCommnad(this);
            DivCommnad_ = new DivCommnad(this);
            PasteResultCommand_ = new PasteResultCommand(this);
            //Counter = new Counter();
            Numbers = new List<NumberWithError>()
            {
                new NumberWithError(null, 0),
                new NumberWithError(null, 0)
            };
            NumResult = new NumberWithError(null, 0);
            numResult = new NumberWithError(null, 0);
        }

        /// <summary>
        /// 他のクラスから参照／設定が行えるようにするためのプロパティの定義
        /// View のXAMLに記述したバインドにより、View Modelからアクセスされる
        /// </summary>

        public double NumAVal
        {
            get
            {
                if (Numbers.Count >= 1)
                {
                    return Numbers[0].Value ?? 0;
                }
                return 0;
            }
            set
            {
                if (Numbers.Count >= 1)
                {
                    Numbers[0].Value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumAVal)));
                }
            }
        }

        public double NumAErr
        {
            get
            {
                if (Numbers.Count >= 1)
                {
                    return Numbers[0].Error;
                }
                return 0;
            }
            set
            {
                if (Numbers.Count >= 1)
                {
                    Numbers[0].Error = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumAErr)));
                }
            }
        }

        public double NumBVal
        {
            get
            {
                if (Numbers.Count >= 2)
                {
                    return Numbers[1].Value ?? 0;
                }
                return 0;
            }
            set
            {
                if (Numbers.Count >= 2)
                {
                    Numbers[1].Value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumBVal)));
                }
            }
        }

        public double NumBErr
        {
            get
            {
                if (Numbers.Count >= 2)
                {
                    return Numbers[1].Error;
                }
                return 0;
            }
            set
            {
                if (Numbers.Count >= 2)
                {
                    Numbers[1].Error = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumBErr)));
                }
            }
        }

        private NumberWithError numResult;
        public NumberWithError NumResult
        {
            get { return numResult; }
            set 
            { 
                numResult = value;
                NumResVal = numResult.Value ?? 0;
                NumResErr = numResult.Error;
            }
        }

        public double NumResVal
        {
            get
            {
                return NumResult.Value ?? 0;
            }
            set
            {
                NumResult.Value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumResVal)));
            }
        }

        public double NumResErr
        {
            get
            {
                return NumResult.Error;
            }
            set
            {
                NumResult.Error = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumResErr)));
            }
        }
    }
}
