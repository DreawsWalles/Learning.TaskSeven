using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Help;

namespace RepositoryLib.JSONRepository
{
    public class JSONAphorismsRepository : IRepository
    {
        public JSONAphorismsRepository()
        {
            if (!Directory.Exists("JSONRepository"))
                Directory.CreateDirectory("JSONRepository");
            if (!File.Exists("JSONRepository/Aphorisms"))
            {
                AskModel[] parametrs = new AskModel[]
                {
                    new AskModel() { Id = 1, Ask = "Драгоценный камень нельзя отполировать без трения. Также и человек не может стать успешным без достаточного количества трудных попыток."},
                    new AskModel() { Id = 2, Ask = "Если тебе плюют в спину — значит ты идешь впереди."},
                    new AskModel() { Id = 3, Ask = "Если в человеке естество затмит воспитанность, получится дикарь, а если воспитанность затмит естество, получится знаток писаний. Лишь тот, в ком естество и воспитанность пребывают в равновесии, может считаться достойным мужем."},
                    new AskModel() { Id = 4, Ask = "Как мы можем знать, что такое смерть, когда мы не знаем еще, что такое жизнь?"},
                    new AskModel() { Id = 5, Ask = "Мудрый человек не делает другим того, чего он не желает, чтобы ему сделали"},
                    new AskModel() { Id = 6, Ask = "Не беспокойся о том, что тебя не знают. Беспокойся о том, достоин ли ты того, чтобы тебя знали."},
                    new AskModel() { Id = 7, Ask = "Не поговорить с человеком, который достоин разговора, значит потерять человека. А говорить с человеком, который разговора не достоин, — значит терять слова. Мудрый не теряет ни людей, ни слов"},
                    new AskModel() { Id = 8, Ask = "Порой мы видим многое, но не замечаем главного."},
                    new AskModel() { Id = 9, Ask = "Три пути ведут к знанию: путь размышления — это путь самый благородный, путь подражания — это путь самый лёгкий и путь опыта — это путь самый горький"},
                    new AskModel() { Id = 10, Ask = "Я не понимаю, как можно иметь дело с человеком, которому нельзя доверять? Если в повозке нет оси, как можно на ней ездить?"},
                    new AskModel() { Id = 11, Ask = "Учитесь так, словно вы постоянно ощущаете нехватку своих знаний, и так, словно вы постоянно боитесь растерять свои знания."},
                    new AskModel() { Id = 12, Ask = "Когда, совершив ошибку, не исправил ее, это и называется совершить ошибку."},
                    new AskModel() { Id = 13, Ask = "Учение без размышления бесполезно, но и размышление без учения опасно."},
                    new AskModel() { Id = 14, Ask = "Не тот велик, кто никогда не падал, а тот велик — кто падал и вставал."},
                    new AskModel() { Id = 15, Ask = "Красота есть во всем, но не всем дано это видеть."},
                    new AskModel() { Id = 16, Ask = "Благородный человек предъявляет требования к себе, низкий человек предъявляет требования к другим."},
                    new AskModel() { Id = 17, Ask = "На самом деле, жизнь проста, но мы настойчиво её усложняем."},
                    new AskModel() { Id = 18, Ask = "Счастье — это когда тебя понимают, большое счастье — это когда тебя любят, настоящее счастье — это когда любишь ты."},
                    new AskModel() { Id = 19, Ask = "Давай наставления только тому, кто ищет знаний, обнаружив свое невежество."},
                    new AskModel() { Id = 20, Ask = "Если ты ненавидишь — значит тебя победили."}
                };
                JsonFiles.Create(parametrs.ToList(), "JSONRepository/Aphorisms");
            }
        }

        public void Add(AskModel model)
        {
            if (model == null)
                throw new Exception("При попытке добавить элемент в JSON репозиторий бьл передан не инициализированый объект");
            JsonFiles.Add(model, "JSONRepository/Aphorisms");
        }

        public string Get(int id)
        {
            if (id < 1 || id > 20)
                throw new Exception("При попытке полечения афаризма из JSON репозитория был передан некорректный id. Значение id должно быть в диапазоне от 1 до 20");
            return JsonFiles.Get(id, "JSONRepository/Aphorisms").Ask;
        }
    }
}
