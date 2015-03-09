package exceptions;

/**
 * Exception class indicating an internal error in the system. This single exception can represent internal errors
 * in the system and limit the number of exceptions that an internal system would need to catch and handle.
 */
public class SystemException extends Exception {

	/** Eclipse generated */
	private static final long serialVersionUID = -5131515151445353378L;
	
	public SystemException( final String message ) {
		super( message );
	}
	
}