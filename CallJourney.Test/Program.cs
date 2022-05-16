using System;
using System.Collections.Generic;

namespace CallJourney.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strs = Console.ReadLine();

            var totalCost = TotalCost(strs);

            Console.WriteLine($"Total cost: {totalCost}");
        }

        static double TotalCost(string args)
        {
            double totalCost = 0;
            Dictionary<TypeEnum,int> dic = new Dictionary<TypeEnum,int>(); 
            
            var strs = args.Split(',');

            if(strs.Length != 0)
            {
                foreach (var str in strs)
                {
                    if(Enum.TryParse(str.Trim(), out TypeEnum item))
                    {
                        if (!dic.ContainsKey(item))
                            dic.Add(item, 1);
                        else
                            dic[item]++;
                    }
                }

                // Promotion for MacBook Pro
                if (dic.ContainsKey(TypeEnum.mbp) && dic.ContainsKey(TypeEnum.vga))
                {
                    dic[TypeEnum.vga] = (dic[TypeEnum.mbp] >= dic[TypeEnum.vga]) ? 0 : dic[TypeEnum.vga] - dic[TypeEnum.mbp];
                    if (dic[TypeEnum.vga] == 0)
                        dic.Remove(TypeEnum.vga);
                }

                // Calculate total cost
                foreach (var item in dic)
                {
                    switch (item.Key)
                    {
                        case TypeEnum.vga:
                            totalCost += dic[TypeEnum.vga] * CostPrice.Vga;
                            break;
                        case TypeEnum.mbp:
                            totalCost += dic[TypeEnum.mbp] * CostPrice.Mbp;
                            break;
                        case TypeEnum.ipd:
                            if(item.Value > 4)
                                totalCost += dic[TypeEnum.ipd] * CostPrice.IpdPromotion;
                            else
                                totalCost += dic[TypeEnum.ipd] * CostPrice.Ipd;
                            break;
                        case TypeEnum.atv:
                            var count = item.Value - item.Value / 3;
                            totalCost += count * CostPrice.Atv;
                            break;
                    }
                }
            }

            return totalCost;
        }
    }
}
