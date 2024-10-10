export interface ApiResponse {
    result: string;
    id: number;
    exception: any;
    status: number;
    isCanceled: boolean;
    isCompleted: boolean;
    isCompletedSuccessfully: boolean;
    isFaulted: boolean;
  }