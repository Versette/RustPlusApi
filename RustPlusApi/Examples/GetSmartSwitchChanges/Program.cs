﻿using Newtonsoft.Json;

using RustPlusApi;

using static __Constants.ExamplesConst;

var rustPlus = new RustPlus(Ip, Port, PlayerId, PlayerToken);
const uint entityId = 0;

rustPlus.OnSmartSwitchTriggered += (_, message) =>
{
    Console.WriteLine($"SmartSwitch:\n{JsonConvert.SerializeObject(message, JsonSettings)}");
};

await rustPlus.ConnectAsync();

var message = await rustPlus.GetSmartSwitchInfoAsync(entityId);
Console.WriteLine($"Infos:\n{JsonConvert.SerializeObject(message, JsonSettings)}");

Console.ReadLine();
await rustPlus.DisconnectAsync();