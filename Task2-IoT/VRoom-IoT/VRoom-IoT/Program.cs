using VRoom_IoT;

var device = new Iot();

while (true)
{
        var statusId = await device.SendIoTData();
        Thread.Sleep(1500);
}
    