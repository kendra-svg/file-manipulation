for i in {1..100};do
    STATUS_NUM=$((RANDOM % 3))
    case $STATUS_NUM in
       0) STATUS="INFO" ;;
       1) STATUS="WARNING" ;;
       2) STATUS="ERROR" ;;
    esac

    MESSAGE="USER LOGGED IN SUCCESSFULLY"
    if [ "$STATUS" == "ERROR" ]; then
        MESSAGE="INCORRECT USERNAME OR PASSWORD"
    elif [ "$STATUS" == "WARNING" ]; then
        MESSAGE="3 LOGIN ATTEMPS REMAINING"
    fi

    TIMESTAMP=$(date -d "today - $((RANDOM % 30)) days" "+%Y-%m-%d %H:%M:%S")

    echo "$TIMESTAMP -$STATUS - $MESSAGE" >> access_random.log
done
