using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GcpClient;
using GcpClient.GcpClient.Runtime;
using GcpClient.Runtime;
using NUnit.Framework;
using UnityEngine.TestTools;

public class EditModeTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NoParamsApiRequestGetTest() => UniTask.ToCoroutine(async () =>
    {
        var httpClient = new BaseHttpClient("https://api.publicapis.org/entries");
        var response = await httpClient.RequestAsync(RequestMethod.Get);
        Assert.IsNotNull(response);
        Assert.IsNotEmpty(response);
    });

    [UnityTest]
    public IEnumerator SimpleParamsApiRequestGetTest() => UniTask.ToCoroutine(async () =>
    {
        var httpClient = new BaseHttpClient("https://api.agify.io");
        var response = await httpClient.RequestAsync(
            requestMethod: RequestMethod.Get,
            parameters: new SimpleParameter[] { new("name", "meelad") });
        Assert.IsNotNull(response);
        Assert.IsNotEmpty(response);
        Assert.AreEqual("{\"age\":32,\"count\":21,\"name\":\"meelad\"}", response);
    });

    [UnityTest]
    public IEnumerator MultipleParamsApiRequestGetTest() => UniTask.ToCoroutine(async () =>
    {
        var httpClient = new BaseHttpClient("https://datausa.io/api/data");
        var response = await httpClient.RequestAsync(RequestMethod.Get,
            parameters: new[]
            {
                new SimpleParameter("drilldowns", "Nation"), new SimpleParameter("measures", "Population")
            });
        Assert.IsNotNull(response);
        Assert.IsNotEmpty(response);
    });
    // TODO: timeout test
    // TODO: failed request test
}