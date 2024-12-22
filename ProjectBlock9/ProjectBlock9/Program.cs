using ProjectBlock9;
using SecurityLibrary;
using SerializerLibrary;
using SerializerLibrary.ExampleDataContractSerializer;
using SerializerLibrary.ExampleSystemTextJson;
using SerializerLibrary.ExampleXmlSerializer;
using System.Security.Cryptography;

//RegularClass regularClass = new RegularClass();


//ExampleDataContractSerializer exampleDataContractSerializer = new ExampleDataContractSerializer();
//exampleDataContractSerializer.Example();

//ExampleXmlSerializer xmlSerializer = new ExampleXmlSerializer();
//xmlSerializer.Example();

//ExampleSystemTextJson exampleSystemTextJson = new ExampleSystemTextJson();
//exampleSystemTextJson.ExampleUtf8Json();

//ExampleJsonConverter exampleJsonConverter = new ExampleJsonConverter();
//exampleJsonConverter.Example();


AesEncryption aesEncryption = new AesEncryption();
aesEncryption.Start();

RsaEncryption rsaEncryption = new RsaEncryption();
rsaEncryption.Start();
