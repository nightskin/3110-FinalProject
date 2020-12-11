import json
import boto3
# Get DB
dynamodb = boto3.resource('dynamodb')
# Get table
UserTable = dynamodb.Table('FinalDB')
# Get all user rows
AllUSers = UserTable.scan()

    


def lambda_handler(event, context):
    # Incoming parameters
    params = event['queryStringParameters']
    # Testing parameters
    # params = {"accountName": "og", "password": "1243"}
    
    
    AccountName = params['accountName']
    Password = params['password']
    
    print(AccountName)
    print(Password)
    
    user_exist = False
    
    
    # If input empty
    if(AccountName == "" or Password == ""):
        return{
            'statusCode': 200,
            'body': json.dumps("Please enter account name and password")
        }
    # Compare to existing names in the table
    for item in AllUSers['Items']:
        if item['Account name'] == AccountName:
            user_exist = True
            print("UserExist")
            return {
                'statusCode': 200,
                'body': json.dumps("User already exist")
            }
    
    
    if not user_exist:   
        # Register user in db
        UserTable.put_item(
          Item = {
                'Account name': AccountName,
                'Password': Password,
            }
        )
        
        return {
            'statusCode': 200,
            'body': json.dumps("Registration success")
        }
    else:
        
        return {
            'statusCode': 200,
            'body': json.dumps("User already exist")
        }
