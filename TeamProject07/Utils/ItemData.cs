﻿using System.ComponentModel;
using TeamProject07.Items;

namespace TeamProject07.Utils
{
    internal class ItemData
    {
        public static Dictionary<int, Item> items;
        public static string path = Define.ItemPath;

        public static void Init()
        {
            items = new Dictionary<int, Item>();
            items.Clear();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        // id 	타입	  파츠	이름	설명	가격	올려지는능력	올려지는수치	내려가는능력	내려가는수치	세트이름

                        if (Define.ItemType.Equip == (Define.ItemType)(int.Parse(data[1]))) // 아이템종류 늘어나면 else if로 추가할것
                        {
                            Equipment item = new Equipment();
                            item.Setting(data[0], data[3], data[4], data[5]);
                            item.Type = (Define.ItemType)(int.Parse(data[1]));

                            item.Part = (Define.Parts)(int.Parse(data[2]));

                            if (data[6] != "") // 능력치 상승효과가 있다면
                            {
                                item.buff = (Define.Buff)(int.Parse(data[6]));
                                item.buffValue = (data[7] == "") ? 0 : int.Parse(data[7]);
                            }
                             
                            if (data[8] != "") // 세트명
                                item.set = (Define.SetEquip)int.Parse(data[8]);

                            items.Add(item.Id, item);
                        }
                        else
                        {
                            ConsumableItem item = new ConsumableItem();
                            item.Setting(data[0], data[3], data[4], data[5]); 
                            item.Type = (Define.ItemType)(int.Parse(data[1]));
                            
                            item.buff = (Define.Buff)(int.Parse(data[6]));
                            item.buffValue = (data[7] == "") ? 0 : int.Parse(data[7]);


                            items.Add(item.Id, item);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("파일을 찾을 수 없습니다.");
            }
        }

    }
}
