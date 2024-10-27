﻿using AnonymousLibrary;
using DeligateLibrary;
using GenericDelegateLibrary;
using System.Linq.Expressions;

//DelegateClass delegateClass = new DelegateClass();

//EventsClass eventsClass = new EventsClass();
//eventsClass.ProcessComplited += delegateClass.ShowMessage;

//eventsClass.OnProcessComplited("Программа завершена!");
//await delegateClass.ExampleDelegateAsync();

//FileDownloader downloader = new FileDownloader();
//downloader.DownloadComplited += Downloder_DownloadComplited;
//downloader.Download("http://example.com/file.zip");


//LambdaClass lambdaClass = new LambdaClass();
////lambdaClass.ExamolePractic();

////lambdaClass.ExampleEvent();

//ActionClass actionClass = new ActionClass();
//actionClass.ExampleParallel();

//FuncClass funcClass = new FuncClass();
//funcClass.ExampleParseMessage();

PredicateClass predicateClass = new PredicateClass();
predicateClass.ExampleValidate();
predicateClass.ExampleValidateRegular();
predicateClass.ExampleSettingsValidate();

//void Downloder_DownloadComplited(object? sender, FileDownloaderEventArgs e)
//{
//    Console.WriteLine($"Загрузка файла {e.FileName} с статусом {e.Message}");
//}

