using ModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewLib;

namespace HistoryLib
{
    public class History
    {
        private IView _view;
        public History(IView view)
        {
            if (view == null)
                throw new Exception("При инициализации класса \"History\" был передан не инициализированный объект");
            if (!Directory.Exists("History"))
                Directory.CreateDirectory("History");
            if (!File.Exists("History/history"))
                using (FileStream file = new FileStream("History/history", FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize<List<HistoryModel>>(file, new List<HistoryModel>());
                }
            _view = view;
        }
        public void DownLoad()
        {
            List<HistoryModel> list;
            using (FileStream file = new FileStream("History/history", FileMode.OpenOrCreate))
            {
                list = JsonSerializer.Deserialize<List<HistoryModel>>(file);
            }
            if (list == null)
                return;
            _view.ViewHistory(list);
        }
        public void Add(HistoryModel model)
        {
            if (model == null)
                throw new Exception("При попытке добавить запись в историю был передан не инициализированный объект");
            List<HistoryModel> list;
            using (FileStream file = new FileStream("History/history", FileMode.OpenOrCreate))
            {
                list = JsonSerializer.Deserialize<List<HistoryModel>>(file);
            }
            list.Add(model);
            using (FileStream file = new FileStream("History/history", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<HistoryModel>>(file, list);
            }
        }
    }
}
