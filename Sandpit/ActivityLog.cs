////#Quick Activity Log Test###################################################
//DateTime recordDateTime = DateTime.Now;
//// get activity logs for the same period.
//var logs = azure.ActivityLogs.DefineQuery()
//        .StartingFrom(recordDateTime.AddDays(-7))
//        .EndsBefore(recordDateTime)
//        .WithAllPropertiesInResponse()
//        .FilterByResource("/subscriptions/bc0b3b15-7d6c-4fa4-b3a7-d208b08fde5c/resourceGroups/DELETE/providers/Microsoft.Sql/servers/testtestdr01")
//        .Execute();

//Console.WriteLine("Activity logs for the Storage Account:");

//foreach (var eventData in logs)
//{

//    //Console.WriteLine("\tDateTime: " + eventData.EventTimestamp);
//    //Console.WriteLine("\tEvent: " + eventData.EventName?.LocalizedValue);
//    //Console.WriteLine("\tOperation: " + eventData.OperationName?.LocalizedValue);
//    //Console.WriteLine("\tCaller: " + eventData.Caller);
//    //Console.WriteLine("\tCorrelationId: " + eventData.CorrelationId);
//    //Console.WriteLine("\tSubscriptionId: " + eventData.SubscriptionId);

//    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", eventData.EventTimestamp, eventData.EventName?.LocalizedValue, eventData.Caller, eventData.CorrelationId, eventData.SubscriptionId, eventData.OperationName?.LocalizedValue);
//    //console.writeline("\tevent: " + eventdata.eventname?.localizedvalue);
//    //console.writeline("\toperation: " + eventdata.operationname?.localizedvalue);
//    //console.writeline("\tcaller: " + eventdata.caller);
//    //console.writeline("\tcorrelationid: " + eventdata.correlationid);
//    //console.writeline("\tsubscriptionid: " + eventdata.subscriptionid);
//}


////#Quick Activity Log Test###################################################