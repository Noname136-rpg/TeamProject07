﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject07.Characters;
using TeamProject07.Utils;

namespace TeamProject07.Status
{
    internal class StatusMain
    {
        public Define.MainGamePhase test(Player player)
        {
            
            Define.MainGamePhase choicePhase;
            Console.Clear();
            Console.WriteLine("플레이어의 정보를 표시합니다");
            Console.WriteLine("\n");
            Console.WriteLine($"LEVEL {player.Level} \t {player.Class}");
            Console.WriteLine($"공격력 : {player.Attack}");
            Console.WriteLine($"방어력 : {player.Defence}");
            Console.WriteLine($"치명타 확률 : {player.CritRate}%");
            Console.WriteLine($"회피 확률 : {player.MissRate}%");
            Console.WriteLine($"체  력 : {player.Hp}");
            Console.WriteLine($"골  드 : {player.Gold}G");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("0. 메인화면");
            Console.WriteLine("0. 메인화면");
            Console.WriteLine("0. 메인화면");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    choicePhase = Define.MainGamePhase.Main;
                    break;
            }
            return Define.MainGamePhase.Main;
        }

        private int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
